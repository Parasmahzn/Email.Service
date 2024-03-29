﻿using Email.Service.Models;
using Microsoft.VisualBasic.FileIO;
using System.Text;

namespace Email.Service.Helpers;

public class Utilities
{
    public static void ExportServiceLog(string logData)
    {
        //var apiConfigLst = new List<WorkerConfig>();
        //if (!string.IsNullOrEmpty(logData))
        //{
        //    apiConfigLst = logData.ToModel<List<WorkerConfig>>();
        //}

        string ExceptionLogPath = Path.Combine(Directory.GetCurrentDirectory(), "App_Data\\");
        string FileName = ExceptionLogPath + "Log" + DateTime.Now.ToString("yyyyMMdd") + ".txt";

        if (!File.Exists(FileName))
        {
            File.Create(FileName).Dispose();
        }
        using StreamWriter sw = File.AppendText(FileName);
        sw.WriteLine("Export Content");
        sw.WriteLine("========================================");
        sw.WriteLine($"START ===> {DateTime.Now}");
        sw.WriteLine($"Response Data ===> {logData}");
        sw.WriteLine($"END ===> {DateTime.Now} ");
        sw.WriteLine();
        sw.WriteLine();
    }

    public static async Task<API.Response> MakeAPICall(API.Request apiRequest)
    {
        try
        {
            var client = new HttpClient();
            var message = new HttpRequestMessage();
            message.Headers.Add("Accept", "application/json");
            message.RequestUri = new Uri(apiRequest.Url);
            client.DefaultRequestHeaders.Clear();
            if (apiRequest.Data != null)
            {
                message.Content = new StringContent(apiRequest.Data.Stringyfy(),
                    Encoding.UTF8, "application/json");
            }

            message.Method = apiRequest.ApiType switch
            {
                SD.ApiType.POST => HttpMethod.Post,
                SD.ApiType.PUT => HttpMethod.Put,
                SD.ApiType.DELETE => HttpMethod.Delete,
                _ => HttpMethod.Get,
            };
            var apiResponse = await client.SendAsync(message);
            var apiContent = await apiResponse.Content.ReadAsStringAsync();
            return new API.Response()
            {
                Success = apiResponse.IsSuccessStatusCode,
                Message = apiResponse.IsSuccessStatusCode ? "success" : "failed",
                Result = !apiResponse.IsSuccessStatusCode ? apiResponse.ReasonPhrase! : apiContent,
                ErrorMessages = !apiResponse.IsSuccessStatusCode ? new List<string> { apiResponse.ReasonPhrase } : new()
            };
        }
        catch (Exception e)
        {
            return new API.Response()
            {
                Message = "Something went wrong",
                ErrorMessages = new List<string> { e.Message }
            };
        }
    }

    public static async Task<List<EmailModel>> GetEmailContent(bool fromFile, bool fromDb, string dataSource = "")
    {
        var emailContent = new List<EmailModel>();

        if (fromFile)
        {
            string appDataPath = Path.Combine(Directory.GetCurrentDirectory(), "App_Data");
            string csvFilePath = Path.Combine(appDataPath, "Email.csv");

            // Read CSV file
            using TextFieldParser parser = new(csvFilePath);
            parser.TextFieldType = FieldType.Delimited;
            parser.SetDelimiters(",");

            int currentRow = 0;

            while (!parser.EndOfData)
            {
                currentRow++;

                string[] fields = parser.ReadFields();

                if (fields != null && currentRow > 1 && fields.Length >= 3) // Skip the first row
                {
                    EmailModel emailModel = new EmailModel
                    {
                        To = fields[0],
                        Subject = fields[1],
                        Body = fields[2]
                    };

                    emailContent.Add(emailModel);
                }
            }
        }

        if (fromDb)
        {

        }

        return emailContent;
    }
}

using Email.Service.Models;

namespace Email.Service.Helpers;

public class Utilities
{
    public static void ExportServiceLog(string logData)
    {
        //dynamic model;
        //if (!string.IsNullOrEmpty(logData))
        //{
        //    model = logData.ToModel<WorkerConfig>();
        //}

        string ExceptionLogPath = Path.Combine(Directory.GetCurrentDirectory(), "App_Data\\");
        string FileName = ExceptionLogPath + "Log" + DateTime.Now.ToString("yyyyMMdd") + ".txt";

        if (!File.Exists(FileName))
        {
            File.Create(FileName).Dispose();
        }
        using StreamWriter sw = File.AppendText(FileName);
        sw.WriteLine("Reversal Detail");
        sw.WriteLine("========================================");
        sw.WriteLine($"START ===> {DateTime.Now}");
        sw.WriteLine($"LOG DATA1 ===> {logData.ToModel<WorkerConfig>().APIURL1} : {logData.ToModel<WorkerConfig>().APIURL1Method} : {logData.ToModel<WorkerConfig>().APIURL1DelayInterval}");
        sw.WriteLine($"LOG DATA2 ===> {logData.ToModel<WorkerConfig>().APIURL2} : {logData.ToModel<WorkerConfig>().APIURL2Method} : {logData.ToModel<WorkerConfig>().APIURL2DelayInterval}");
        sw.WriteLine($"LOG DATA3 ===> {logData.ToModel<WorkerConfig>().APIURL3} : {logData.ToModel<WorkerConfig>().APIURL3Method} : {logData.ToModel<WorkerConfig>().APIURL3DelayInterval}");
        sw.WriteLine($"END ===> {DateTime.Now} ");
        sw.WriteLine();
        sw.WriteLine();
    }
}

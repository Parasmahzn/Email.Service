using Newtonsoft.Json;
namespace Email.Service.Helpers;

public static class Extensions
{
    public static T MapObject<T>(this object item)
    {
        T? sr = default;
        if (item != null)
        {
            var obj = JsonConvert.SerializeObject(item);
            sr = JsonConvert.DeserializeObject<T>(obj);
        }
        return sr!;
    }

    public static T ToModel<T>(this string json)
    {
        T? model = JsonConvert.DeserializeObject<T>(json);
        return model!;
    }

    public static string Stringyfy(this object obj)
    {
        try
        {
            string serializedObject = JsonConvert.SerializeObject(obj);
            return serializedObject;
        }
        catch (Exception)
        {
            return string.Empty;
        }
    }
}

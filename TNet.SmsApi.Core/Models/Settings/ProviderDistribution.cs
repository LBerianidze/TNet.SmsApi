namespace TNet.SmsApi.Core.Models.Settings;

public class ProviderDistribution
{
    public int BeelineProvider { get; set; }
    public int GeocellProvider { get; set; }
    public int MagtiProvider { get; set; }

    public Dictionary<string, int> ToDictionary()
    {
        return GetType().GetProperties().Select(t => new { t.Name, Value = (int)t.GetValue(this)! })
            .OrderBy(f => f.Value)
            .ToDictionary(t => t.Name, t => t.Value);
    }
}
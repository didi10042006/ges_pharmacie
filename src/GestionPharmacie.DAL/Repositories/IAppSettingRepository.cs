namespace GestionPharmacie.DAL.Repositories;

public interface IAppSettingRepository
{
    Task<string?> GetValueAsync(string key);
    Task<Dictionary<string, string>> GetAllSettingsAsync();
    Task SetValueAsync(string key, string value);
}

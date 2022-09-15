using System.ComponentModel;
using System.Text;

namespace SpiderNet.Scripter.Edital;

public class Edital
{
    public enum PropertyEnum
    {
        Licitador,
        Municipio,
        UF,
        NumeroEdital,
        NumeroProcesso,
        Modalidade,
        Objeto,
        DataHoraPrazoProposta,
        DataHoraCertame
    }

    private IEnumerable<PropertyEnum> _key;
    private IEnumerable<PropertyEnum> _keyRevisao;
    
    private string? _licitador;

    public string? Licitador
    {
        set
        {
            _licitador = value;
            OnPropertyChanged(PropertyEnum.Licitador);
        }
        get => _licitador;
    }
    public string? Municipio { get; set; }
    public string? UF { get; set; }
    public string? NumeroEdital { get; set; }
    public string? NumeroProcesso { get; set; }
    public string? Modalidade { get; set; }
    public string? Objeto { get; set; }
    public DateTime? DataHoraPrazoProposta { get; set; }
    public DateTime? DataHoraCertame { get; set; }

    public string? Key => GetKey(_key);
    public string? KeyRevisao => GetKey(_keyRevisao);

    public Edital(IEnumerable<PropertyEnum> key, IEnumerable<PropertyEnum> keyRevisao)
    {
        _key = key;
        _keyRevisao = keyRevisao;
    }
    
    private void OnPropertyChanged(PropertyEnum propertyEnum)
    {
        if (!_key.Contains(propertyEnum) && !_keyRevisao.Contains(propertyEnum)) return;
        
        if (Key is not null && KeyRevisao is not null)
        {
            
        }
    }

    private string? GetKey(IEnumerable<PropertyEnum> key)
    {
        var values = new List<string>();
        
        foreach (var property in key)
        {
            var value = GetValue(property);
            if (value is not null)
                values.Add(value);
            else
                return null;
        }

        return string.Join(" | ", values);
    }

    // returns the value of the property as string
    private string? GetValue(PropertyEnum propertyEnum)
    {
        switch (propertyEnum)
        {
            case PropertyEnum.Licitador:
            case PropertyEnum.Municipio:
            case PropertyEnum.UF:
            case PropertyEnum.NumeroEdital:
            case PropertyEnum.NumeroProcesso:
            case PropertyEnum.Modalidade:
            case PropertyEnum.Objeto:
                return (string?) GetType().GetProperty(propertyEnum.ToString()).GetValue(this);                
            case PropertyEnum.DataHoraPrazoProposta:
            case PropertyEnum.DataHoraCertame:
                return ((DateTime?) GetType().GetProperty(propertyEnum.ToString()).GetValue(this))?.ToString("dd/MM/yyyy HH:mm:ss");
            default:
                throw new ArgumentOutOfRangeException(nameof(propertyEnum), propertyEnum, null);
        }
    }
}
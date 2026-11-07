using System;
using System.ComponentModel;
using System.Reflection;

public static class EnumExtensions
{

    public static string ObterDescricao(this Enum valorEnum)
    {
        FieldInfo field = valorEnum.GetType().GetField(valorEnum.ToString());

        if (field == null) return valorEnum.ToString();

        DescriptionAttribute[] atributos = (DescriptionAttribute[])field.GetCustomAttributes(typeof(DescriptionAttribute), false);

        return atributos.Length > 0 ? atributos[0].Description : valorEnum.ToString();
    }
}
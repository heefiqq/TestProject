using System.ComponentModel;

namespace ForTest.Core.Data.Enums
{
    public enum ESortOrder
    {
        [Description("Нет")]
        NoSorting = 0,

        [Description("Id по возростанию")]
        AscByCustomerId = 1,

        [Description("Id по убыванию")]
        DescByCustomerId = 2,

        [Description("Имя по возростанию")]
        AscByName = 3,

        [Description("Имя по убыванию")]
        DescByName = 4,

        [Description("Дата по возростанию")]
        AscByBirthDay = 5,

        [Description("Дата по убыванию")]
        DescByBirthDay = 6,

        [Description("Пол по возростанию")]
        AscByGender = 7,

        [Description("Пол по убыванию")]
        DescByGender = 8,

        [Description("Заявок по возростанию")]
        AscByQuantityRequest = 9,

        [Description("Заявок по убыванию")]
        DescByQuantityRequest = 10
    }
}

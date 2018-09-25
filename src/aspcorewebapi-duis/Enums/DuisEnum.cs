using aspcorewebapi_duis.Atributtes;

namespace aspcorewebapi_duis.Enums
{
    public enum DuisEnum
    {
        None = 0,//0000
        
        [EnumFieldText("GET")] //0001
        S = 1,
        [EnumFieldText("POST")] //0010
        I = 2,
        [EnumFieldText("POST,GET")] //0011
        IS = 3,
        [EnumFieldText("PUT")] //0100
        U = 4,
        [EnumFieldText("PUT,GET")] //0101
        US = 5,
        [EnumFieldText("PUT,POST")] //0110
        UI = 6,
        [EnumFieldText("PUT,POST,GET")] //0111
        UIS = 7,
        [EnumFieldText("DELETE")]//1000
        D = 8,
        [EnumFieldText("DELETE,GET")] //1001
        DS = 9,
        [EnumFieldText("DELETE,POST")] //1010
        DI = 10,
        [EnumFieldText("DELETE,POST,GET")] //1011
        DIS = 11,
        [EnumFieldText("DELETE,PUT")] //1100
        DU = 12,
        [EnumFieldText("DELETE,PUT,GET")] //1101
        DUS = 13,
        [EnumFieldText("DELETE,PUT,POST")] //1110
        DUI = 14,
        [EnumFieldText("DELETE,PUT,POST,GET")] //1111
        DUIS = 15
    }
}
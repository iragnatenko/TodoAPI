using TodoAPIMediatr.Entity;
using TodoAPIMediatr.Model;

namespace TodoAPIMediatr.Converter
{
    public static class DataClsConverter
    {
        public static DataCls Convert(this DataClsEntity from)
        {
            return new DataCls()
            {
                Base64 = from.Base64

            };
        }

        public static DataClsEntity Convert(this DataCls from)
        {
            return new DataClsEntity()
            {
                Base64 = from.Base64

            };
        }
    }
}

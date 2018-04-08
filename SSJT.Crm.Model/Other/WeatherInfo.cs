using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSJT.Crm.Model
{
    public class WeatherInfo:BaseModel
    {
        /// <summary>
        /// 省
        /// </summary>
        public string Province { get; set; }
        /// <summary>
        /// 当前城市
        /// </summary>
        public string City { get; set; }
        /// <summary>
        /// 城市代码
        /// </summary>
        public string CityCode { get; set; }
        /// <summary>
        /// 城市图片
        /// </summary>
        public string CityImage { get; set; }
        /// <summary>
        /// 城市描述
        /// </summary>
        public string CityDesc { get; set; }
        /// <summary>
        /// 更新时间时间
        /// </summary>
        public DateTime? LastModifyDate { get; set; }
        /// <summary>
        /// 星期几
        /// </summary>
        public string Week { get; set; }

        /// <summary>
        /// 今天摄氏温度
        /// </summary>
        public string TempC1{ get; set; }
        /// <summary>
        /// 第二天的摄氏温度
        /// </summary>
        public string TempC2{ get; set; }
        /// <summary>
        /// 第三天的摄氏温度
        /// </summary>
        public string TempC3 { get; set; }
        /// <summary>
        /// 今天的华氏温度
        /// </summary>
        //public string TempF1 { get; set; }
        ///// <summary>
        ///// 明天的华氏温度
        ///// </summary>
        //public string TempF2 { get; set; }
        ///// <summary>
        ///// 后天的华氏温度
        ///// </summary>
        //public string TempF3 { get; set; }
        /// <summary>
        /// 今天的天气描述
        /// </summary>
        public string WeatherDesc1 { get; set; }
        /// <summary>
        /// 明天的天气描述
        /// </summary>
        public string WeatherDesc2 { get; set; }
        /// <summary>
        /// 后天的天气描述
        /// </summary>
        public string WeatherDesc3 { get; set; }

        /// <summary>
        /// 今天的天气图标
        /// </summary>
        public string ImageFrom1 { get; set; }
        /// <summary>
        /// 明天的天气图标
        /// </summary>
        public string ImageFrom2 { get; set; }
        /// <summary>
        /// 后天的天气图标
        /// </summary>
        public string ImageFrom3 { get; set; }
        /// <summary>
        /// 今天的天气图标
        /// </summary>
        public string ImageTo1 { get; set; }
        /// <summary>
        /// 明天的天气图标
        /// </summary>
        public string ImageTo2 { get; set; }
        /// <summary>
        /// 后天的天气图标
        /// </summary>
        public string ImageTo3 { get; set; }
        /// <summary>
        /// 今天及之后三天的风速描述
        /// </summary>
        public string Wind1 { get; set; }
        public string Wind2 { get; set; }
        public string Wind3 { get; set; }

        /// <summary>
        /// 天气实况
        /// </summary>
        public string WeatherLive { get; set; }
        /// <summary>
        /// 天气指数
        /// </summary>
        public string WeatherIndex { get; set; }
        ///// <summary>
        ///// 感冒指数
        ///// </summary>
        //public string ColdIndex { get; set; }
        ///// <summary>
        ///// 血糖指数
        ///// </summary>
        //public string GlycemicIndex { get; set; }
        ///// <summary>
        ///// 洗车指数
        ///// </summary>
        //public string CarWashIndex { get; set; }
        ///// <summary>
        ///// 空气污染指数
        ///// </summary>
        //public string AirPollutionIndex { get; set; }
        ///// <summary>
        ///// 湿度
        ///// </summary>
        //public string Humidity { get; set; }
        ///// <summary>
        ///// 紫外线强度
        ///// </summary>
        //public string Index_UV { get; set; }

        ///// <summary>
        ///// 空气质量
        ///// </summary>
        //public string AirQuality { get; set; }

    }
}

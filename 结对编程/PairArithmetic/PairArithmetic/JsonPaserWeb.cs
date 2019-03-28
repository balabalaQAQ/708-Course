using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
namespace PairArithmetic
{
    public class JsonPaserWeb
    {
        // Object->Json
        public string Serialize(Subject obj)
        {
            JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();
            string json = jsonSerializer.Serialize(obj);
            return json;
        }

        // Json->Object
        public Subject Deserialize(string json)
        {
            JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();
            //执行反序列化
            Subject obj = jsonSerializer.Deserialize<Subject>(json);
            return obj;
        }
    }
}

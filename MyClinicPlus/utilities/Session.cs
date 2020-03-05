using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClinicPlus.utilities
{
    public class Session
    {
        Dictionary<string,object> _data = new Dictionary<string,object>();
        
        public void pustData(string key,object value)
        {
            _data.Add(key, value);
        }

        public string GetData(string key)
        {
            var data = _data.Where(x => x.Key.Contains(key)).Select(x => x.Key).FirstOrDefault();
            return data;
        } 
    }
}

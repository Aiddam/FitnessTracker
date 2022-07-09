using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace FitnessTracker.BL.Controller
{
    public abstract class ControllerBase
    {
        /// <summary>
        /// Сохранить данные пользователя
        /// </summary>
        protected void Save(string FileName,object item)
        {
            var formatter = new BinaryFormatter();
            using (var fileStream = new FileStream(FileName, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fileStream, item);
            }
        }
        protected T Load <T>(string FileName)
        {
            var formatter = new BinaryFormatter();
            using (var fileStream = new FileStream(FileName, FileMode.OpenOrCreate))
            {
                if (fileStream.Length > 0 && formatter.Deserialize(fileStream) is T items)
                {
                    return items;
                }
                else
                {
                    return default(T);
                }
            }
        }
    }
}

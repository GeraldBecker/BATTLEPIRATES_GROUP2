using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace BattlePirates_Group2 {
    

    public static class SerializationHelper {

        public static TransmitMessage Serialize(object anySerializableObject) {
            using(var memoryStream = new MemoryStream()) {
                (new BinaryFormatter()).Serialize(memoryStream, anySerializableObject);
                return new TransmitMessage { Data = memoryStream.ToArray() };
            }
        }

        public static object Deserialize(TransmitMessage message) {
            using(var memoryStream = new MemoryStream(message.Data)) {
                object temp = null;
                memoryStream.Position = 0;
                try {
                    foreach(byte b in message.Data) {
                    }
                    Console.WriteLine();
                    if(!memoryStream.CanRead) {
                    }

                    temp = (new BinaryFormatter()).Deserialize(memoryStream);
                } catch(System.ArgumentNullException) {
                } catch(System.Runtime.Serialization.SerializationException ex) {
                } finally {
                }
                return temp;

            }

        }

    }
}

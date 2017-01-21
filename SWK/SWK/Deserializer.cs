using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace SWK
{
    public class Deserializer
    {
       public List<EventSong> DeserializeSong()
       {
           var listReturn = new List<EventSong>();
           XElement songXml = XElement.Load(@"Song.xml");
           IEnumerable<XElement> textSegs = from seg in songXml.Descendants("Event")
                                            select (XElement)seg;

           foreach(var item in textSegs)
           {
               //Si tiene NoteOff/On
               if (item.Descendants("NoteOff").Any() || item.Descendants("NoteOn").Any())
               { 
                   XElement desc = null;
                   var on = false;
                   if(item.Descendants("NoteOff").Any())
                   {
                       desc = item.Descendants("NoteOff").First();
                   }
                   else
                   {
                       desc = item.Descendants("NoteOn").First();
                       on = true;
                   }

                   listReturn.Add(new EventSong()
                   {
                       Note = int.Parse(desc.Attribute("Note").Value),
                       On = on,
                       TimeAbs = long.Parse(item.Descendants("Absolute").First().Value),
                       Velocity = int.Parse(desc.Attribute("Velocity").Value)
                   });
               }
           }

           return listReturn;
       }
    }

    public class EventSong
    {
        public long TimeAbs { get; set; }
        public int Note { get; set; }
        public int Velocity { get; set; }
        public bool On { get; set; }

        public TimeSpan Time { get; set; }
        public short Position { get; set; }
        public char Type { get; set; }
    }
}



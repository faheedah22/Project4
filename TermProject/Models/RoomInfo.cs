using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TermProject.Models
{
    public class RoomInfo
    {
        private int id;
        private string roomTitle;
        private double roomWidth;
        private double roomLength;
        private int roomLevel;
        public RoomInfo()
        {

        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public string RoomTitle
        {
            get { return roomTitle; }
            set { roomTitle = value; }
        }
        public double RoomWidth
        {
            get { return roomWidth; }
            set { roomWidth = value; }
        }

        public double RoomLength
        {
            get { return roomLength; }
            set { roomLength = value; }
        }

        public int RoomLevel
        {
            get { return roomLevel; }
            set { roomLevel = value; }
        }
    }
}

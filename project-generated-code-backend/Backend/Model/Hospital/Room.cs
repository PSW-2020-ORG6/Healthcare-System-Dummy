// File:    Room.cs
// Author:  Luka Doric
// Created: Friday, May 15, 2020 23:46:22
// Purpose: Definition of Class Room

using Backend.Model.Util;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Model.Hospital
{
    public class Room : Entity
    {
        private int id;
        private RoomType roomType;
        private List<Equipment> equipment;
        private string roomTypeSerialNumber;
        private string style;

        public string Name { get; set; }
        public int Id { get => id; set { id = value; } }
        public string FloorSerialNumber { get; set; }
        public string BuildingSerialNumber { get; set; }
        public string RoomTypeSerialNumber { get => roomTypeSerialNumber; set { roomTypeSerialNumber = value; } }
        public virtual RoomType RoomType { get => roomType; set { roomType = value; } }
        public virtual List<Equipment> Equipment
        {
            get
            {
                if (equipment == null)
                    equipment = new List<Equipment>();
                return equipment;
            }
            set
            {
                RemoveAllEquipment();
                if (value != null)
                {
                    foreach (Equipment oEquipment in value)
                        AddEquipment(oEquipment);
                }
            }
        }
        public int Row { get; set; }
        public int Column { get; set; }
        public int RowSpan { get; set; }
        public int ColumnSpan { get; set; }
        public string Style { get => style; set { style = value; } }

        public Room()
        {

        }

        public void AddEquipment(Equipment newEquipment)
        {
            if (newEquipment == null)
                return;
            if (this.equipment == null)
                this.equipment = new List<Equipment>();
            if (!this.equipment.Contains(newEquipment))
                this.equipment.Add(newEquipment);
        }

        public void RemoveEquipment(Equipment oldEquipment)
        {
            if (oldEquipment == null)
                return;
            if (this.equipment != null)
                if (this.equipment.Contains(oldEquipment))
                    this.equipment.Remove(oldEquipment);
        }

        public void RemoveAllEquipment()
        {
            if (equipment != null)
                equipment.Clear();
        }

        [JsonConstructor]
        public Room(String serial, int id, RoomType roomType) : base(serial)
        {
            this.SerialNumber = serial;
            this.id = id;
            this.roomType = roomType;
            this.equipment = new List<Equipment>();

        }

        public Room(int id, RoomType roomType) : base()
        {
            this.id = id;
            this.roomType = roomType;
            this.equipment = new List<Equipment>();
        }

        public override bool Equals(object obj)
        {
            Room other = obj as Room;
            if (other == null)
            {
                return false;
            }
            return this.Id.Equals(other.Id) && this.RoomType.Equals(other.RoomType);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return this.id.ToString();
        }

        public bool ContainsAllEquipment(List<Equipment> requiredEquipment)
        {
            foreach (Equipment e in requiredEquipment)
            {
                if (!this.Equipment.Contains(e))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
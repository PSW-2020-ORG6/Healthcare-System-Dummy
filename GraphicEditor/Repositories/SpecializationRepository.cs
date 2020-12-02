﻿using GraphicEditor.Repositories.Interfaces;
using Model.Accounts;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace GraphicEditor.Repositories
{
    public class SpecializationRepository : ISpecializationRepository
    {
        private MySqlConnection connection;

        public SpecializationRepository()
        {
            connection = new MySqlConnection("server=localhost;port=3306;database=mydb;user=root;password=root");
        }

        private List<Specialization> GetSpecializations(String query)
        {
            connection.Close();
            connection.Open();
            MySqlCommand sqlCommand = new MySqlCommand(query, connection);
            MySqlDataReader sqlReader = sqlCommand.ExecuteReader();
            List<Specialization> resultList = new List<Specialization>();
            while (sqlReader.Read())
            {
                Specialization entity = new Specialization();
                entity.SerialNumber = (string)sqlReader[0];
                entity.Name = (string)sqlReader[1];
                resultList.Add(entity);
            }
            connection.Close();
            return resultList;
        }

        public List<Specialization> GetSpecializationsBySerialNumber(string serialNumber)
        {
            try
            {
                return GetSpecializations("Select * from specialization where SerialNumber='" + serialNumber + "'");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public string GetSpecializationsNameBySerialNumber(string serialNumber)
        {
            try
            {
                List<Specialization> specializations = GetSpecializations("Select * from specialization where SerialNumber='" + serialNumber + "'");
                string allSpecializations = "";
                foreach (Specialization s in specializations)
                    allSpecializations += s.Name;
                return allSpecializations;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public Specialization GetSpecializationBySerialNumber(string serialNumber)
        {
            try
            {
                return GetSpecializations("Select * from specialization where SerialNumber='" + serialNumber + "'")[0];
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public List<Specialization> GetSpecializationByName(string name)
        {
            try
            {
                return GetSpecializations("Select * from specialization where Name like '%" + name + "%'");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }
    }
}

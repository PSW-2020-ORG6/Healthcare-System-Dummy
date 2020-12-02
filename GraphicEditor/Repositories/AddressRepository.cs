﻿using GraphicEditor.Repositories.Interfaces;
using Model.Util;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace GraphicEditor.Repositories
{
    public class AddressRepository : IAddressRepository
    {
        private MySqlConnection connection;

        public AddressRepository()
        {
            connection = new MySqlConnection("server=localhost;port=3306;database=mydb;user=root;password=root");
        }

        private List<Address> GetAddresses(String query)
        {
            connection.Close();
            connection.Open();
            MySqlCommand sqlCommand = new MySqlCommand(query, connection);
            MySqlDataReader sqlReader = sqlCommand.ExecuteReader();
            List<Address> resultList = new List<Address>();
            while (sqlReader.Read())
            {
                Address entity = new Address();
                entity.SerialNumber = (string)sqlReader[0];
                entity.Street = (string)sqlReader[1];
                resultList.Add(entity);
            }
            connection.Close();
            return resultList;
        }

        public List<Address> GetAllAddresses()
        {
            try
            {
                return GetAddresses("Select * from addresses");
            }
            catch (Exception)
            {
                return null;
            }
        }

        public Address GetAddressBySerialNumber(string serialNumber)
        {
            try
            {
                return GetAddresses("Select * from addresses where SerialNumber='" + serialNumber + "'")[0];
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public List<Address> GetAddressesByStreet(string street)
        {
            try
            {
                return GetAddresses("Select * from addresses where Street='" + street + "'");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }
    }
}

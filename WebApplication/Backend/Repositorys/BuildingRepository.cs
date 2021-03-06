﻿// using MySql.Data.MySqlClient;
// using System;
// using System.Collections.Generic;
// using HealthClinicBackend.Backend.Model.Hospital;
// using WebApplication.Backend.Repositorys.Interfaces;
//
// namespace WebApplication.Backend.Repositorys
// {
//     public class BuildingRepository : IBuildingRepository
//     {
//         private MySqlConnection connection;
//         private FloorRepository floorRepository = new FloorRepository();
//
//         public BuildingRepository()
//         {
//             connection = new MySqlConnection("server=localhost;port=3306;database=mydb;user=root;password=root");
//         }
//
//         private List<Building> GetBuildings(String query)
//         {
//             connection.Open();
//             MySqlCommand sqlCommand = new MySqlCommand(query, connection);
//             MySqlDataReader sqlReader = sqlCommand.ExecuteReader();
//             List<Building> resultList = new List<Building>();
//             while (sqlReader.Read())
//             {
//                 Building entity = new Building();
//                 entity.SerialNumber = (string)sqlReader[0];
//                 entity.Name = (string)sqlReader[1];
//                 entity.Color = (string)sqlReader[2];
//                 entity.Row = (int)sqlReader[3];
//                 entity.Column = (int)sqlReader[4];
//                 entity.Style = (string)sqlReader[5];
//                 entity.Floors = floorRepository.GetFloorsByBuildingSerialNumber((string)sqlReader[0]);
//                 resultList.Add(entity);
//             }
//             connection.Close();
//             return resultList;
//         }
//
//         public List<Building> GetAllBuildings()
//         {
//             try
//             {
//                 return GetBuildings("Select * from building");
//             }
//             catch (Exception)
//             {
//                 return null;
//             }
//         }
//
//         public List<Building> GetBuildingsByName(string name)
//         {
//             try
//             {
//                 return GetBuildings("Select * from building where Name like '%" + name + "%'");
//             }
//             catch (Exception)
//             {
//                 return null;
//             }
//         }
//
//         public Building GetBuildingBySerialNumber(string serialNumber)
//         {
//             try
//             {
//                 return GetBuildings("Select * from building where SerialNumber='" + serialNumber + "'")[0];
//             }
//             catch (Exception e)
//             {
//                 Console.WriteLine(e.Message);
//                 return null;
//             }
//         }
//     }
// }

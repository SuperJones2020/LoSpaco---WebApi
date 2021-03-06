﻿using System.Collections.Generic;
using  LoSpacoWebAPi.Models;

namespace  LoSpacoWebAPi.DAO {
    public abstract class CategoryDAO {
        public static List<Category> GetList() {
            var list = new List<Category>();
            Database.ReaderRows(Database.ReturnCommand("select * from tbCategories"), row => {
                list.Add(new Category((byte)row[0], (string)row[1]));
            });
            return list;
        }

        public static Category GetByName(string name) {
            object[] row = Database.ReaderRow(Database.ReturnCommand($"select * from tbCategories where catname = '{name}'"));
            return new Category((byte)row[0], (string)row[1]);
        }

        public static Category GetById(byte id) {
            object[] row = Database.ReaderRow(Database.ReturnCommand($"select * from tbCategories where categoryid = '{id}'"));
            return new Category((byte)row[0], (string)row[1]);
        }
    }
}
﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Slide06
{
    public class Student
    {
        public string LastName { get; set; }
        public string Group { get; set; }
    }

    public class Program
    {
        public static void MainX()
        {
            var students = new List<Student>
            {
                new Student { LastName="Jones", Group="FT-1" },
                new Student { LastName="Adams", Group="FT-1" },
                new Student { LastName="Williams", Group="KN-1"},
                new Student { LastName="Brown", Group="KN-1"}
            };

            var result = new List<string>();
            foreach (var s in students)
                if (s.Group == "KN-1")
                    result.Add(s.LastName);

            //или
            result = students.Where(z => z.Group == "KN-1").Select(z => z.LastName).ToList();
        }
    }
}
using System;
using System.Collections;
using System.Collections.Generic;

namespace HashJoin
{
    class Program
    {
        private static List<User> users = new List<User>();
        private static List<Department> departments = new List<Department>();
        private static List<UserDepartmentJoin> join = new List<UserDepartmentJoin>();
        static void Main(string[] args)
        {
            departments.AddRange(new List<Department>
            {
                    new Department { Id = "D1", ManagerId = "MGR1", Name = "Human Resources" },
                    new Department { Id = "D2", ManagerId = "MGR2", Name = "Sales"},
                    new Department { Id = "D3", ManagerId = "MGR3", Name = "Information Technologies" }
            });
            users.AddRange(new List<User>
            {
                new User { Id = "U1", Name = "Julia", DepartmentId = "D2" },
                new User { Id = "U2", Name = "Ivan", DepartmentId = "D3" },
                new User { Id = "U3", Name = "Sergey", DepartmentId = "D3" },
                new User { Id = "U4", Name = "Jessy", DepartmentId = "D1" },
                new User { Id = "U5", Name = "Carina", DepartmentId = "D1" },
            });

            JoinByDepartmentId(departments, users);

            foreach(var item in join)
            {
                Console.WriteLine($"{item.UserId}\t{item.Name}\t{item.DepartmentId}\t{item.DepartmentName}\t\t{item.ManagerId}");
            }
            Console.ReadLine();
        }

        private static void JoinByDepartmentId(List<Department> departments, List<User> users)
        {
            Hashtable ht = new Hashtable();
            if (departments.Count > users.Count)
            {
                departments.ForEach(d =>
                {
                    if (ht.ContainsKey(d.Id))
                    {
                        (ht[d.Id] as List<UserDepartmentJoin>).Add(new UserDepartmentJoin
                        {
                            DepartmentId = d.Id,
                            DepartmentName = d.Name,
                            ManagerId = d.ManagerId
                        });
                    }
                    else {
                        ht.Add(d.Id, new List<UserDepartmentJoin>
                        {
                            new UserDepartmentJoin
                            {
                                DepartmentId = d.Id,
                                DepartmentName = d.Name,
                                ManagerId = d.ManagerId
                            }
                        });
                    }
                });
                foreach(var u in users)
                {
                    if (ht[u.DepartmentId] != null)
                    {
                        var entries = ht[u.DepartmentId] as List<UserDepartmentJoin>;
                        foreach(var entry in entries)
                        {
                            entry.Name = u.Name;
                            entry.UserId = u.Id;
                            join.Add(entry);
                        }
                    }
                }

            } else
            {
                users.ForEach(u =>
                {
                    if (ht.ContainsKey(u.DepartmentId))
                    {
                        (ht[u.DepartmentId] as List<UserDepartmentJoin>)
                            .Add(new UserDepartmentJoin
                            {
                                UserId = u.Id,
                                Name = u.Name,
                                DepartmentId = u.DepartmentId
                            });
                    }
                    else
                    {
                        ht.Add(u.DepartmentId, new List<UserDepartmentJoin>
                        {
                            new UserDepartmentJoin
                            {
                                UserId = u.Id,
                                Name = u.Name,
                                DepartmentId = u.DepartmentId
                            }
                        }
                        );
                    }
                });
                 
                foreach(var d in departments)
                {
                    if (ht[d.Id] != null)
                    {
                        var entries = ht[d.Id] as List<UserDepartmentJoin>;
                        foreach (var entry in entries)
                        {
                            entry.DepartmentId = d.Id;
                            entry.DepartmentName = d.Name;
                            entry.ManagerId = d.ManagerId;
                            join.Add(entry);
                        }
                    }
                }
            }
        }
    }
}

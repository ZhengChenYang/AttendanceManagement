﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace attendanceManagement.XML
{
    class StudentInfo
    {
        public String name { get; set; }
        public String id { get; set; }
        public String college { get; set; }
        public String major { get; set; }
        public String sex { get; set; }
        public String macAdr { get; set; }
        public String ts { get; set; }
        public String te { get; set; }
        public String sclass { get; set; }

        // 0未到 1-3早退 4-6迟到 7到课 8请假
        //第一次考勤到课+1 第二次考勤到课+2 第三次考勤到课+4
        public int check { get; set; } = -1;
        public StudentInfo(String name, String id, String college, String major, String sex, String macAdr, String sclass)
        {
            this.name = name;
            this.id = id;
            this.college = college;
            this.major = major;
            this.sex = sex;
            this.macAdr = macAdr;
            this.sclass = sclass;
        }

        //第一次考勤到达，result+1
        public void firstArrival()
        {
            check += 1;
        }

        //第二次考勤到达，result+2
        public void secondArrival()
        {
            check += 2;
        }

        //第三次考勤到达，result+4
        public void thirdArrival()
        {
            check += 4;
        }
    }
    
    //CurrentCourse类为单例,当前要考勤的课程
    class CurrentCourse
    {
        private static CurrentCourse instance = new CurrentCourse();

        private String courseId;
        private String courseName;
        private String teacherId;
        private String teacherName;
        private String week;
        private String startTime;
        private String endTime;
        private String firstTime; 
        private String secondTime;
        private String thirdTime;
        
        private int studentNr;
        public StudentInfo[] students;

        
        private CurrentCourse()
        { }  
        
        //获得唯一实例
        public static CurrentCourse getInstance()
        {
            return instance;
        }
        
        //设置实例的基本信息  该方法由ZXmlDocument调用
        public void setCourse(String courseId, String courseName, String teacherId, String teacherName, int number)
        {
            this.courseId = courseId;
            this.courseName = courseName;
            this.teacherId = teacherId;
            this.teacherName = teacherName;   
            this.studentNr = number;
            //直接设置students数组内学生的数据
            students = new StudentInfo[studentNr];
        }

        //设置实例的时间信息 该方法由ZXmlDocument调用
        public void setTime(String week, String start, String end)
        {
            this.startTime = start;
            this.endTime = end;
            this.week = week;

            //设置3次考勤时间，暂时省略
            //....
        }

        //获得表格填充的数据，一个二维string 数组
        public String[,] getTableContent()
        {
            String[,] data = new String[studentNr,4];
            for(int i=0;i<studentNr;i++)
            {
                data[i,0] = students[0].name;
                data[i,1] = students[0].college;
                data[i,2] = students[0].major;
                data[i,3] = students[0].id;
            }
            return data;
        }

        //返回
        public List<StudentInfo> getStudentList()
        {
            List<StudentInfo> list = new List<StudentInfo>();
            foreach(StudentInfo stu in students)
            {
                list.Add(stu);
            }
            return list;
        }

        public String getCourseId()
        {
            return courseId;
        }
    }
}

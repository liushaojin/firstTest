using System;
using System.Collections.Generic;
using System.Text;

namespace WindowsApplication1
{
    using System.Data.SQLite;
    class DataHander
    {
        //数据库连接
        SQLiteConnection m_dbConnection;
        string mDbPathStr = "Data/MyDatabase.sqlite";    //相对路径

        public DataHander()
        {
            createNewDatabase();
            connectToDatabase();
            createTable();
            fillTable();
            printHighscores();
        }

        //创建一个空的数据库
        void createNewDatabase()
        {
            SQLiteConnection.CreateFile ( mDbPathStr );
        }

        //创建一个连接到指定数据库
        void connectToDatabase()
        {
            string mDbConnectStr = string.Format ( "Data Source={0};Version=3;", mDbPathStr );

            m_dbConnection = new SQLiteConnection ( mDbConnectStr );
            m_dbConnection.Open();
        }

        //在指定数据库中创建一个table
        void createTable()
        {
            string sql = "create table highscores (name varchar(20), score int)";
            SQLiteCommand command = new SQLiteCommand ( sql, m_dbConnection );
            command.ExecuteNonQuery();
        }

        //插入一些数据
        void fillTable()
        {
            string sql = "insert into highscores (name, score) values ('Me', 3000)";
            SQLiteCommand command = new SQLiteCommand ( sql, m_dbConnection );
            command.ExecuteNonQuery();

            sql = "insert into highscores (name, score) values ('Myself', 6000)";
            command = new SQLiteCommand ( sql, m_dbConnection );
            command.ExecuteNonQuery();

            sql = "insert into highscores (name, score) values ('And I', 9001)";
            command = new SQLiteCommand ( sql, m_dbConnection );
            command.ExecuteNonQuery();
        }

        //使用sql查询语句，并显示结果
        void printHighscores()
        {
            string sql = "select * from highscores order by score desc";
            SQLiteCommand command = new SQLiteCommand ( sql, m_dbConnection );
            SQLiteDataReader reader = command.ExecuteReader();

            while ( reader.Read() )
            {
                Console.WriteLine ( "Name: " + reader["name"] + "\tScore: " + reader["score"] );
            }

            Console.ReadLine();
        }
    }

}

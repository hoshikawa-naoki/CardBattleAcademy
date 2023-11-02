using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataBaseConnector : MonoBehaviour
{

    //DB�ɃA�N�Z�X����ۂ̈���ݒ�(�T�[�o���\�z����ۂɕύX�̕K�v����)
    string SERVER = "localhost";
    string DATABASE = "cardbattleacademy";
    string USERID = "root";
    string PORT = "3306";
    string PASSWORD = "";

    // Start is called before the first frame update
    void Start()
    {
        string connCmd =
       "server=" + SERVER + ";" +
       "database=" + DATABASE + ";" +
       "userid=" + USERID + ";" +
       "port=" + PORT + ";" +
       "password=" + PASSWORD;

        //�ڑ�����DB���w�肷��
        MySqlConnection conn = new(connCmd);

        try
        {
            Debug.Log("MySQL�Ɛڑ����c");

            //DB�Ɛڑ�����
            conn.Open();

            //SQL��
            string sql = "SELECT * FROM test;";

            //SQL����DB�ɓn��
            MySqlCommand cmd = new(sql, conn);

            //SQL�������s�������ʂ��󂯎��
            MySqlDataReader rdr = cmd.ExecuteReader();

            //�擾�������ʂɎ��̍s������ΌJ��Ԃ�
            while (rdr.Read())
            {
                //1��ځFrdr[0]�E2��ځFrdr[1]...
                Debug.Log("text_id:" + rdr[0] + ", text:" + rdr[1]);
            }

            //���ʂ̕ێ�����߂�
            rdr.Close();

        }
        catch (Exception ex)
        {
            Debug.Log(ex.ToString());

            //DB�Ƃ̐ڑ���ؒf����
            conn.Close();
            Debug.Log("�ڑ����I�����܂���");
        }

        //DB�Ƃ̐ڑ���ؒf����
        conn.Close();
        Debug.Log("�ڑ����I�����܂���");

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

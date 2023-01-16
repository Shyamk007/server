namespace DAL;

using BOL;
using System.Data;
using MySql.Data.MySqlClient;

public class PlayerDataAccess
{

    public static string conString = @"server=localhost; port=3306; user=root; password=Stark@1203; database=playerinfo";

    public static List<Player> GetAllPlayers()
    {
        List<Player> allNotes = new List<Player>();
        MySqlConnection con = new MySqlConnection(conString);

        try
        {
            con.Open();
            string query = "select * from players";
            DataSet ds = new DataSet();
            MySqlCommand cmd = new MySqlCommand(query, con);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(ds);

            DataTable dt = ds.Tables[0];
            DataRowCollection rows = dt.Rows;
            foreach (DataRow row in rows)
            {
                Player players = new Player
                {
                    userid = int.Parse(row["userid"].ToString()),
                    playername = row["playername"].ToString(),
                    sport = row["sport"].ToString(),
                    dob = row["dob"].ToString()
                };
                allNotes.Add(players);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        finally
        {
            con.Close();
        }
        return allNotes;
    }

    public static void SaveNewPlayer(Player player)
    {
        MySqlConnection con = new MySqlConnection(conString);
        try
        {
            con.Open();
            string query = $"insert into players(playername, sport, dob) values('{player.playername}','{player.sport}','{player.dob}')";
            MySqlCommand command = new MySqlCommand(query, con);
            command.ExecuteNonQuery();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        finally
        {
            con.Close();
        }
    }

    public static void DeletePlayerById(int id)
    {
        MySqlConnection con = new MySqlConnection(conString);

        try
        {
            con.Open();
            string query = "delete from players where userid =" + id;
            MySqlCommand command = new MySqlCommand(query, con);
            command.ExecuteNonQuery();

        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        finally
        {
            con.Close();
        }
    }

}
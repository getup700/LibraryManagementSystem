using LMS.Dal.Entities;
using LMS.Dal.Extensions;
using LMS.Dal.Utils;
using Microsoft.Data.SqlClient;
using System.Data;

namespace LMS.Dal;

public class UserDao : IEntityDao<User>
{
    private SqlConnection conn => GetSqlConnection();
    private readonly RoleDao _roleDao;

    public UserDao(RoleDao roleDao)
    {
        _roleDao = roleDao;
    }

    public UserDao()
    {
        //conn = GetSqlConnection();
    }

    public int Create(User user)
    {
        //using var conn = GetSqlConnection();
        var cmdTxt =
            @"INSERT INTO T_Users(Id,Name,State,Email,RegistrationTime,PhoneNumber_RegionNumber,PhoneNumber_Number,Birthday)
            VALUES (@Id,@Name,@State,@Email,@RegistrationTime,@PhoneNumber_Region,@PhoneNumber_Number,@Birthday)";
        //执行存储过程
        using var command = new SqlCommand(cmdTxt, conn);
        command.Parameters.AddWithValue("@Id", user.Id);
        command.Parameters.AddWithValue("@Name", user.Name);
        command.Parameters.AddWithValue("@State", 1);
        command.Parameters.AddWithValue("@Email", user.Email);
        command.Parameters.AddWithValue("@RegistrationTime", user.RegistrationTime);
        command.Parameters.AddWithValue("@PhoneNumber_Region", 86);
        command.Parameters.AddWithValue("@PhoneNumber_Number", user.PhoneNumber);
        command.Parameters.AddWithValue("@Birthday", user.BirthDay);

        if (conn.State == ConnectionState.Closed)
        {
            conn.OpenIfClosed();
        }
        var result = command.ExecuteNonQuery();
        conn.CloseIfOpen();
        return result;
    }

    public List<User> GetByName(string name)
    {
        var cmdTxt =
            @"SELECT * FROM T_Users
            WHERE State = 1
            AND Name = @Name";

        using var command = new SqlCommand(cmdTxt, conn);
        command.Parameters.AddWithValue("@Name", name);

        var reader = command.ExecuteReader();
        var users = new List<User>();
        while (reader.Read())
        {
            var user = InitialEnitty(reader);

            
            users.Add(user);
        }
        conn.CloseIfOpen();
        return users;
    }

    public User GetById(Guid userId)
    {
        //using var conn = GetSqlConnection();
        using var command = new SqlCommand("SP_Display_UserById", conn)
        {
            CommandType = CommandType.StoredProcedure
        };
        command.Parameters.AddWithValue("@UserId", userId);

        var reader = command.ExecuteReader();

        if (!reader.Read())
        {
            throw new Exception("未读取到数据");
        }
        var user = InitialEnitty(reader);
        return user;
    }

    public List<User> GetAll()
    {
        //using var conn = GetSqlConnection();
        var cmdTxt = "SELECT * FROM T_Users WHERE State = 1";
        using var command = new SqlCommand(cmdTxt, conn);
        var reader = command.ExecuteReader();
        var result = new List<User>();
        while (reader.Read())
        {
            var user = InitialEnitty(reader);
            result.Add(user);
        }
        conn.CloseIfOpen();
        return result;
    }

    public async Task<List<User>> GetAllAsync()
    {
        //using var conn = GetSqlConnection();
        var cmdTxt = "SELECT * FROM T_Users WHERE State = 1";
        using var command = new SqlCommand(cmdTxt, conn);
        var reader = await command.ExecuteReaderAsync();
        var users = new List<User>();
        while (reader.Read())
        {
            var user = InitialEnitty(reader);
            users.Add(user);
        }
        conn.CloseIfOpen();
        return users;
    }

    /// <summary>
    /// 获取总页数
    /// </summary>
    /// <param name="pageSize"></param>
    /// <returns></returns>
    public async Task<int> GetPageCount(int pageSize)
    {
        //using var conn = GetSqlConnection();

        var cmdTxt = "SELECT COUNT(*) FROM T_Users WHERE State = 1";
        using var cmd = new SqlCommand(cmdTxt, conn);
        //await conn.OpenAsync();
        var totalCount = 0;
        var result = await cmd.ExecuteScalarAsync();
        if (result != DBNull.Value)
        {
            totalCount = Convert.ToInt32(result);
        }

        conn.CloseIfOpen();
        //获取总页数
        var pageCount = (int)Math.Ceiling(totalCount / (double)pageSize);
        return pageCount;
    }

    /// <summary>
    /// 分页查询
    /// </summary>
    /// <param name="pageNumber"></param>
    /// <param name="pageSize"></param>
    /// <returns></returns>
    public async Task<List<User>> GetPageAsync(int pageNumber, int pageSize)
    {
        var pageCount = await GetPageCount(pageSize);
        if (pageNumber > pageCount)
        {
            pageNumber = pageCount;
        }

        //using var conn = GetSqlConnection();
        var cmdTxt = @"
        SELECT * 
        FROM T_Users
        WHERE State = 1
        ORDER BY Id
        OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY;
        ";
        using var command = new SqlCommand(cmdTxt, conn);

        var offset = (pageNumber - 1) * pageSize;

        command.Parameters.AddWithValue("@Offset", offset);
        command.Parameters.AddWithValue("@PageSize", pageSize);

        using var reader = await command.ExecuteReaderAsync();

        var users = new List<User>();
        while (await reader.ReadAsync())
        {
            var user = InitialEnitty(reader);

            users.Add(user);
        }

        conn.CloseIfOpen();
        return users;
    }

    public int Delete(Guid userId)
    {
        //using var conn = GetSqlConnection();
        var cmdTxt =
            @"DELETE FROM T_Users
            WHERE Id = @Id";
        using var command = new SqlCommand(cmdTxt, conn);
        command.Parameters.AddWithValue("@Id", userId);

        var result = command.ExecuteNonQuery();
        conn.CloseIfOpen();
        return result;
    }

    public int Update(User user)
    {
        //using var conn = GetSqlConnection();
        var cmdTxt =
            @"UPDATE T_Users
            SET Name = @Name,Email = @Email,PhoneNumber_Number = @Number,Birthday = @Birthday,RegistrationTime = @RegistrationTime
            WHERE Id = @Id";

        using var command = new SqlCommand(cmdTxt, conn);

        command.Parameters.AddWithValue("@Id", user.Id);
        command.Parameters.AddWithValue("@Name", user.Name);
        command.Parameters.AddWithValue("@Email", user.Email);
        command.Parameters.AddWithValue("@Number", user.PhoneNumber);
        command.Parameters.AddWithValue("@Birthday", user.BirthDay == null ? DBNull.Value : user.BirthDay);
        command.Parameters.AddWithValue("@RegistrationTime", user.RegistrationTime);
        var result = command.ExecuteNonQuery();
        conn.CloseIfOpen();
        return result;
    }

    private User InitialEnitty(SqlDataReader reader)
    {
        var id = reader.GetGuid(reader.GetOrdinal("Id"));
        var user = new User(id);
        user.Name = reader.IsDBNull("Name") ? null : reader.GetString("Name");
        user.Email = reader.IsDBNull("Email") ? null : reader.GetString("Email");
        user.PhoneNumber = reader.IsDBNull("PhoneNumber_Number") ? "" : reader.GetString("PhoneNumber_Number");
        user.BirthDay = reader.IsDBNull("Birthday") ? null : reader.GetDateTime("Birthday");
        user.RegistrationTime = reader.IsDBNull("RegistrationTime") ? null : reader.GetDateTime("RegistrationTime");
        return user;
    }

    private static SqlConnection GetSqlConnection()
    {
        SqlConnection conn = null;
        try
        {
            var connStr = ConnUtil.GetUserDbStrings();
            conn = new SqlConnection(connStr);
            if (conn.State == ConnectionState.Closed)
            {
                conn.OpenIfClosed();
            }
        }
        catch (Exception e)
        {
            throw new Exception("数据库连接失败", e);
        }
        return conn;
    }
}
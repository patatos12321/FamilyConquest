using DataContracts;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RegisterManagerBehavior : MonoBehaviour
{
    public string Color { get; set; }
    public Color RealColor { get; set; }

    private InputField usernameField;
    private string password = "";
    void Start()
    {
        usernameField = FindObjectOfType<InputField>();
    }

    public void AddColor(string color)
    {
        password += color;
    }

    

    public void Register()
    {
        ValidatePlayer();
        var player = GetPlayer();
        HttpClientHelper.SetToken(HttpClientHelper.Post<string>("/Player/Register", player));
        GoToMainMenu();
    }

    public void Login()
    {
        ValidatePlayer();
        var player = GetPlayer();
        var loginResult = HttpClientHelper.Post<string>("/Player/Register", player);
        HttpClientHelper.SetToken(loginResult);
        GoToMainMenu();
    }

    private Player GetPlayer()
    {
        var sha = new System.Security.Cryptography.SHA256Managed();
        byte[] textData = System.Text.Encoding.UTF8.GetBytes(password);
        byte[] hash = sha.ComputeHash(textData);
        return new Player() { HashedPassword = BitConverter.ToString(hash).Replace("-", string.Empty), Username = usernameField.text };
    }

    private void ValidatePlayer()
    {
        if (string.IsNullOrWhiteSpace(usernameField.text))
        {
            usernameField.Select();
            throw new Exception("Empty username");
        }
        if (string.IsNullOrWhiteSpace(password))
        {
            throw new Exception("Empty password");
        }
    }

    

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GoToLogin()
    {
        SceneManager.LoadScene("Login");
    }

    public void GoToRegister()
    {
        SceneManager.LoadScene("Register");
    }
    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}

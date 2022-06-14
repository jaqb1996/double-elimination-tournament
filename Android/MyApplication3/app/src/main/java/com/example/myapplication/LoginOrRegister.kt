package com.example.myapplication

import android.content.Context
import android.content.Intent
import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import android.view.View
import org.json.JSONArray
import com.google.gson.Gson
import com.google.gson.reflect.TypeToken
import java.io.File
import java.io.FileWriter
import java.io.PrintWriter
import android.os.Environment
import android.util.Log
import android.widget.EditText
import android.widget.TextView
import com.android.volley.Request
import com.android.volley.Response
import com.android.volley.toolbox.JsonObjectRequest
import com.android.volley.toolbox.Volley
import org.json.JSONException
import org.json.JSONObject

class Tournament {}

class LoginOrRegister : AppCompatActivity() {
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_login_or_register)
    }
    fun come_back(view: View) {
        val intent = Intent(this, MainActivity::class.java).apply {
        }
        startActivity(intent)
    }
    fun register(view: View) {
        val intent = Intent(this, Register::class.java).apply {
        }
        startActivity(intent)
    }
    fun login(view: View) {
        val intent = Intent(this, ListOfTournaments::class.java).apply {
        }
        val login: EditText = findViewById(R.id.send_login)
        val password: EditText = findViewById(R.id.send_password)
        //val values = mapOf("email" to "user4@email.com", "password" to "123") //values for test

        val values = mapOf("email" to login.text.toString(), "password" to password.text.toString())

        fun getJsonDataFromAsset(context: Context, fileName: String): String? {
            val jsonString: String
            try {
                jsonString = context.assets.open(fileName).bufferedReader().use { it.readText() }
            } catch (ioException: Exception) {
                ioException.printStackTrace()
                return null
            }
            return jsonString
        }

        //POBIERA DANE Z JSONA KTORY NIE MOZE EDYTOWAC
        val jsonFileString = getJsonDataFromAsset(applicationContext, "tournaments.json")
        val gson = Gson()
        val listPersonType = object : TypeToken<List<Tournament>>() {}.type
        var tournaments: List<Tournament> = gson.fromJson(jsonFileString, listPersonType)
        val items = JSONArray(jsonFileString)

        //ZAPISUJE DO PAMIECI TELEFONU LISTE W JSON
        val path_external = Environment.getExternalStoragePublicDirectory(Environment.DIRECTORY_DOCUMENTS)
        val path = File(path_external, "/"+"tournaments.json")

        try {
            PrintWriter(FileWriter(path))
                .use { it.write(items.toString()) }
        } catch (e: Exception) {
            e.printStackTrace()
        }

        //Logowanie
        val url = "http://jaqbklo.somee.com/api/authentication/login"
        val queue = Volley.newRequestQueue(this)
        val jsonObject = JSONObject(values)

        val textView0: TextView = findViewById(R.id.textView8)
        val request = JsonObjectRequest(
            Request.Method.POST,url,jsonObject,
            Response.Listener { response ->
                try {
                    textView0.text = "Prawidłowe dane do logowania"
                    //Log.e("Token login", response!!.toString())
                    val intent = Intent(this, ListOfTournaments::class.java).apply {
                    }
                    intent.putExtra("Token",response!!.toString())
                    startActivity(intent)
                }
                catch (e: JSONException){
                    textView0.text = "Błąd logowania"
                }
            },
            Response.ErrorListener {
                    error ->  textView0.text = "Błąd logowania"
                //error -> Log.e("ErrorListener Rest resp",  error.toString())
            })
        //request.setShouldCache(false)
        queue.add(request)
    }
}


package com.example.myapplication

import android.content.Context
import android.content.Intent
import android.os.Bundle
import android.os.Environment
import android.util.Log
import android.view.View
import android.widget.EditText
import android.widget.TextView
import androidx.appcompat.app.AppCompatActivity
import com.android.volley.AuthFailureError
import com.android.volley.Request
import com.android.volley.Response
import com.android.volley.toolbox.JsonObjectRequest
import com.android.volley.toolbox.Volley
import org.json.JSONArray
import org.json.JSONException
import org.json.JSONObject
import java.io.File
import java.io.FileWriter
import java.io.PrintWriter

class CreateTournament : AppCompatActivity() {
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_create_tournament)
    }

    fun logout(view: View) {
        val intent = Intent(this, LoginOrRegister::class.java).apply {
        }
        startActivity(intent)
    }

    fun come_back(view: View) {
        val intent = Intent(this, ListOfTournaments::class.java).apply {
        }
        startActivity(intent)
    }

    fun add_new_tournament(view: Context, new_tournament: JSONObject){
        //Odczytuje z pamięci telefona z folderu Documents
        val path_external = Environment.getExternalStoragePublicDirectory(Environment.DIRECTORY_DOCUMENTS)
        val path = File(path_external, "/"+"tournaments.json")
        val jsonFileString = path.bufferedReader().use { it.readText() }
        val items = JSONArray(jsonFileString)
        //Dodaje nowy turniej
        items.put(new_tournament)

        //ZAPISUJE DO PAMIECI w TELEFONie odnowiony JSON
        try {
            PrintWriter(FileWriter(path))
                .use { it.write(items.toString()) }
        } catch (e: Exception) {
            e.printStackTrace()
        }
    }

    fun create_tournament(view: View) {
        val token = intent.getStringExtra("Token")
        val name: EditText = findViewById(R.id.name)
        val amount_group: EditText = findViewById(R.id.amount_group)
        val groupe_names: EditText = findViewById(R.id.groupe_names)

        val new_tournament = JSONObject()
        try {
            new_tournament.put("Name", name.text)
            new_tournament.put("NumberOfContestants", amount_group.text.toString().toInt())
            val grNames3 = JSONArray()
            var group_name = ""
            var i = 0; var cnt = 0;
            val nr: Int = amount_group.text.toString().toInt()
            for(elem in groupe_names.text.toString()){
                cnt+=1
                if (elem == '\n'){
                    i +=1
                    val js = JSONObject()
                    grNames3.put(js.put("Name", group_name))
                    group_name = ""
                } else if (groupe_names.text.toString().endsWith(elem) && i == nr - 1) {
                    i +=1; group_name += elem.toString()
                    val js = JSONObject()
                    grNames3.put(js.put("Name", group_name))
                } else{
                    group_name += elem.toString()
                }
            }
            new_tournament.put("Teams", grNames3)
        } catch (e: JSONException) {
            e.printStackTrace()
        }
        add_new_tournament(applicationContext, new_tournament)

        val url = "http://jaqbklo.somee.com/api/tournament/create"
        val queue = Volley.newRequestQueue(this)
        val jsonObject = new_tournament

        Log.e("Data ", jsonObject.toString())
        val textView0: TextView = findViewById(R.id.textView10)
        val request = object : JsonObjectRequest(
            Request.Method.POST,url,jsonObject,
            Response.Listener { },
            Response.ErrorListener {error -> Log.e("errorListner", error.toString())
                if ("ClientError" in error.toString()){
                    textView0.text = "Proszę sprawdzić wprowadzane dane"
                } else{
                    textView0.text = "Pomyślne tworzenie"
                    val intent = Intent(this, ListOfTournaments::class.java).apply { }
                    intent.putExtra("Token",token)
                    startActivity(intent)
                }
            }){
            @Throws(AuthFailureError::class)
            override fun getHeaders(): Map<String, String> {
                val headers = HashMap<String, String>()
                headers.put("Content-Type", "application/json")
                val tokenCode = token.toString().substring(10, token.toString().length-2)
                headers.put("Authorization", "Bearer $tokenCode")
                return headers
            }
        }
        queue.add(request)
    }
}
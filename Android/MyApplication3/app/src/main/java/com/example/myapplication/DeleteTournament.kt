package com.example.myapplication

import android.content.Intent
import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import android.util.Log
import android.view.View
import android.widget.TextView
import com.android.volley.AuthFailureError
import com.android.volley.Request
import com.android.volley.Response
import com.android.volley.toolbox.JsonObjectRequest
import com.android.volley.toolbox.Volley

class DeleteTournament : AppCompatActivity() {
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_delete_tournament)
        val name = intent.getStringExtra("name").toString()
        val textView0: TextView = findViewById(R.id.textView9)
        textView0.text = "Na pewno chcesz usunąć $name?"
    }

    fun delete_tournament(view: View){
        val token = intent.getStringExtra("Token")
        val url = intent.getStringExtra("url")
        val queue = Volley.newRequestQueue(this)
        val request =  object :  JsonObjectRequest(
            Request.Method.DELETE,url, null,
            Response.Listener {  },
            Response.ErrorListener { error ->
                try {
                    val intent = Intent(this, ListOfTournaments::class.java).apply {}
                    intent.putExtra("Token",token)
                    startActivity(intent)
                    Log.e("Try",  error.toString())
                } catch (e : com.android.volley.ParseError){
                    Log.e("Catch",  error.toString())
                }
            }) {
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

    fun come_back(view: View) {
        val token = intent.getStringExtra("Token")
        val intent = Intent(this, ListOfTournaments::class.java).apply { }
        intent.putExtra("Token",token.toString())
        startActivity(intent)
    }
}
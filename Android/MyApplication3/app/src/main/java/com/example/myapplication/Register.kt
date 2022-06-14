package com.example.myapplication

import android.content.Intent
import android.os.Bundle
import android.util.Log
import android.view.View
import android.widget.EditText
import android.widget.TextView
import androidx.appcompat.app.AppCompatActivity
import com.android.volley.Request
import com.android.volley.Response
import com.android.volley.toolbox.JsonArrayRequest
import com.android.volley.toolbox.JsonObjectRequest
import com.android.volley.toolbox.Volley
import org.json.JSONArray
import org.json.JSONObject


class Register : AppCompatActivity() {
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_register_view)
    }
    fun come_back(view: View) {
        val intent = Intent(this, LoginOrRegister::class.java).apply {
        }
        startActivity(intent)
    }

    fun go_to_main_page(view: View) {
        val login: EditText = findViewById(R.id.send_login2)
        val password: EditText = findViewById(R.id.send_password3)
        val password2: EditText = findViewById(R.id.send_password4)
        val values = mapOf("email" to login.text.toString(),
            "password" to password.text.toString(),
            "passwordConfirmation" to password2.text.toString())

        val url = "http://jaqbklo.somee.com/api/user/register"
        val queue = Volley.newRequestQueue(this)
        val jsonObject = JSONObject(values)
        //val jsonArray = JSONArray(values)
        //Log.i("Data:", jsonObject.toString())

        val textView0: TextView = findViewById(R.id.textView7)
        val request = JsonObjectRequest(
            Request.Method.POST,url,jsonObject,
            Response.Listener {
                    //error -> Log.e("Listner", error.toString())
            },
            Response.ErrorListener {
                    error -> //Log.e("errorListner", error.toString())
                if ("ClientError" in error.toString()){
                    textView0.text = "Niepowodzenie"
                } else if ("ParseError" in error.toString()){
                    textView0.text = "Pomyślna rejestracja"
                    val intent = Intent(this, LoginOrRegister::class.java).apply {
                    }
                    startActivity(intent)
                }
            })
        queue.add(request)
    }
}
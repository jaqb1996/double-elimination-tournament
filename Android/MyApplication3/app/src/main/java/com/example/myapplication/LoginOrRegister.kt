package com.example.myapplication

import android.content.Intent
import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import android.provider.AlarmClock.EXTRA_MESSAGE
import android.view.View
import android.widget.TextView

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
        val intent = Intent(this, RegisterView::class.java).apply {
        }
        startActivity(intent)
    }
    fun login(view: View) {
        val intent = Intent(this, ListOfTournaments::class.java).apply {
        }
        startActivity(intent)
    }
}
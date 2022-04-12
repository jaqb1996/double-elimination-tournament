package com.example.myapplication

import android.content.Intent
import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import android.provider.AlarmClock.EXTRA_MESSAGE
import android.view.View
import android.widget.EditText

class MainActivity : AppCompatActivity() {
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_main)
    }

    fun login(view: View) {
        val intent = Intent(this, LoginOrRegister::class.java).apply {
        }
        startActivity(intent)
    }

    fun watch_the_tournament(view: View) {
        val intent = Intent(this, watchTheTournament::class.java).apply {
        }
        startActivity(intent)
    }
}


package com.example.myapplication

import android.content.Intent
import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import android.view.View

class CreateTournament : AppCompatActivity() {
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_create_tournament)
    }
    fun come_back(view: View) {
        val intent = Intent(this, LoginOrRegister::class.java).apply {
        }
        startActivity(intent)
    }

    fun create_tournament(view: View) {
        val intent = Intent(this, ListOfTournaments::class.java).apply {
        }
        startActivity(intent)
    }
}
package com.example.myapplication

import android.content.Intent
import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import android.view.View

class watchTheTournament : AppCompatActivity() {
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_watch_the_tournament)
    }
    fun come_back(view: View) {
        val intent = Intent(this, MainActivity::class.java).apply {
        }
        startActivity(intent)
    }
}
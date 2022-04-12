package com.example.myapplication

import android.content.Intent
import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import android.view.View

class EditTournament : AppCompatActivity() {
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_edit_tournament)
    }

    fun come_back(view: View) {
        val intent = Intent(this, ListOfTournaments::class.java).apply {
        }
        startActivity(intent)
    }
}
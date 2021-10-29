package com.track_it.track_it_mobile;

import android.media.Image;
import android.os.Bundle;
import android.text.Editable;
import android.text.TextWatcher;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.view.animation.Animation;
import android.view.animation.AnimationUtils;
import android.widget.Button;
import android.widget.EditText;
import android.widget.ImageView;
import android.widget.TextView;

import androidx.annotation.NonNull;
import androidx.fragment.app.Fragment;
import androidx.navigation.fragment.NavHostFragment;

public class FirstFragment extends Fragment {

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
    {
        // Inflate the layout for this fragment
        return inflater.inflate(R.layout.fragment_first, container, false);
    }

    public void onViewCreated(@NonNull View view, Bundle savedInstanceState) {
        super.onViewCreated(view, savedInstanceState);

        EditText txtUsername = (EditText) view.findViewById(R.id.txtUsername);
        Button btnLogin = (Button) view.findViewById(R.id.btnLogin);
        TextView lblTracking = (TextView) view.findViewById(R.id.lblTracking);
        ImageView imgTracking = (ImageView) view.findViewById(R.id.imgSync);

        lblTracking.setVisibility(View.INVISIBLE);
        imgTracking.setVisibility(View.INVISIBLE);

        Animation rotateAnimation = AnimationUtils.loadAnimation(getContext(), R.anim.rotate_anim);

        txtUsername.addTextChangedListener(new TextWatcher() {
            @Override
            public void onTextChanged(CharSequence s, int start, int before, int count) {
                if(btnLogin.getText().toString().trim().toLowerCase().equals("logged in"))
                {
                    btnLogin.setText("Login");
                    imgTracking.clearAnimation();
                    lblTracking.setVisibility(View.INVISIBLE);
                    imgTracking.setVisibility(View.INVISIBLE);
                }
            }

            @Override
            public void beforeTextChanged(CharSequence s, int start, int count, int after) { }

            @Override
            public void afterTextChanged(Editable s) { }
        });

        btnLogin.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                if (txtUsername.getText().toString().trim().toLowerCase().equals("gamer") && !btnLogin.getText().toString().trim().toLowerCase().equals("logged in"))
                {
                    btnLogin.setText("Logged In");
                    lblTracking.setVisibility(View.VISIBLE);
                    imgTracking.setVisibility(View.VISIBLE);

                    imgTracking.startAnimation(rotateAnimation);
                }
            }
        });
    }
}
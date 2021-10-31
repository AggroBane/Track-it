package com.track_it.track_it_mobile;

import android.Manifest;
import android.annotation.SuppressLint;
import android.app.Activity;
import android.app.AlertDialog;
import android.content.Context;
import android.content.DialogInterface;
import android.content.pm.PackageManager;
import android.graphics.Color;
import android.location.Location;
import android.location.LocationListener;
import android.location.LocationManager;
import android.os.Bundle;
import android.text.Editable;
import android.text.Html;
import android.text.TextWatcher;
import android.util.Log;
import android.view.Gravity;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.view.animation.Animation;
import android.view.animation.AnimationUtils;
import android.view.inputmethod.InputMethodManager;
import android.widget.Button;
import android.widget.EditText;
import android.widget.ImageView;
import android.widget.TextView;

import androidx.annotation.NonNull;
import androidx.coordinatorlayout.widget.CoordinatorLayout;
import androidx.core.app.ActivityCompat;
import androidx.fragment.app.Fragment;

import com.android.volley.Request;
import com.android.volley.RequestQueue;
import com.android.volley.Response;
import com.android.volley.VolleyError;
import com.android.volley.toolbox.JsonObjectRequest;
import com.android.volley.toolbox.Volley;
import com.google.android.material.floatingactionbutton.ExtendedFloatingActionButton;
import com.google.android.material.snackbar.Snackbar;

import org.json.JSONException;
import org.json.JSONObject;

public class FirstFragment extends Fragment {
    private final String username = "gamer";
    private final String errorTextColor = "#F2C2C2";
    private final String successTextColor = "#C2F2C2";
    private final int locationRefreshInterval = 600000; // 10 min

    private Location currentLocation = new Location("Track-It Mobile");
    private boolean providerEnabled = true;
    private boolean loggedIn = false;

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState) {
        return inflater.inflate(R.layout.fragment_first, container, false);
    }

    private void ShowSnackBar(View v, String text, String textColorHex) {
        Snackbar snackbar = Snackbar.make(v.findViewById(R.id.btnSend), text, Snackbar.LENGTH_SHORT);
        View snackView = snackbar.getView();

        CoordinatorLayout.LayoutParams params = (CoordinatorLayout.LayoutParams) snackView.getLayoutParams();
        params.gravity = Gravity.CENTER_HORIZONTAL | Gravity.TOP;
        params.setMargins(0, 110, 0, 0);

        snackView.setLayoutParams(params);
        snackView.setBackgroundColor(Color.parseColor("#2f2f2f"));

        TextView snackTextView = snackView.findViewById(com.google.android.material.R.id.snackbar_text);
        snackTextView.setTextAlignment(View.TEXT_ALIGNMENT_CENTER);
        snackbar.setTextColor(Color.parseColor(textColorHex));

        snackbar.show();
    }

    private void AskLocationPermission(Context context) {
        final AlertDialog.Builder builder = new AlertDialog.Builder(context);

        builder.setMessage("The GPS needs to be enabled. Allow GPS and Internet access ?").setCancelable(false).setPositiveButton(Html.fromHtml("<font color='" + successTextColor + "'>Allow</font>"), new DialogInterface.OnClickListener() {
            @Override
            public void onClick(DialogInterface dialog, int which) {
                ActivityCompat.requestPermissions(getActivity(), new String[]{Manifest.permission.INTERNET, Manifest.permission.ACCESS_FINE_LOCATION, Manifest.permission.ACCESS_BACKGROUND_LOCATION}, 1);

                if (ActivityCompat.checkSelfPermission(getContext(), Manifest.permission.ACCESS_FINE_LOCATION) != PackageManager.PERMISSION_GRANTED ||
                        ActivityCompat.checkSelfPermission(getContext(), Manifest.permission.ACCESS_BACKGROUND_LOCATION) != PackageManager.PERMISSION_GRANTED ||
                        ActivityCompat.checkSelfPermission(getContext(), Manifest.permission.INTERNET) != PackageManager.PERMISSION_GRANTED)
                {
                    AskLocationPermission(getContext());
                }
            }
        }).setNegativeButton(Html.fromHtml("<font color='" + errorTextColor + "'>Quit</font>"), new DialogInterface.OnClickListener() {
            @Override
            public void onClick(DialogInterface dialog, int which) {
                System.exit(0);
            }
        });

        builder.create().show();
    }

    @SuppressLint("MissingPermission")
    public void onViewCreated(@NonNull View view, Bundle savedInstanceState) {
        super.onViewCreated(view, savedInstanceState);

        EditText txtUsername = (EditText) view.findViewById(R.id.txtUsername);
        Button btnLogin = (Button) view.findViewById(R.id.btnLogin);
        TextView lblTracking = (TextView) view.findViewById(R.id.lblTracking);
        ImageView imgTracking = (ImageView) view.findViewById(R.id.imgSync);
        ExtendedFloatingActionButton btnSend = (ExtendedFloatingActionButton) view.findViewById(R.id.btnSend);

        lblTracking.setVisibility(View.INVISIBLE);
        imgTracking.setVisibility(View.INVISIBLE);
        btnSend.shrink();
        btnSend.hide();

        Animation rotateAnimation = AnimationUtils.loadAnimation(getContext(), R.anim.rotate_anim);

        ActivityCompat.requestPermissions(getActivity(), new String[]{ Manifest.permission.INTERNET, Manifest.permission.ACCESS_FINE_LOCATION, Manifest.permission.ACCESS_BACKGROUND_LOCATION }, 1);

        LocationManager locationManager = (LocationManager) getContext().getSystemService(Context.LOCATION_SERVICE);

        if (ActivityCompat.checkSelfPermission(getContext(), Manifest.permission.ACCESS_FINE_LOCATION) != PackageManager.PERMISSION_GRANTED ||
                ActivityCompat.checkSelfPermission(getContext(), Manifest.permission.ACCESS_BACKGROUND_LOCATION) != PackageManager.PERMISSION_GRANTED ||
                ActivityCompat.checkSelfPermission(getContext(), Manifest.permission.INTERNET) != PackageManager.PERMISSION_GRANTED)
        {
            AskLocationPermission(getContext());
        }
        else {
            LocationListener locationListener = new LocationListener() {
                @Override
                public void onLocationChanged(final Location location) {
                    currentLocation = location;

                    try {
                        SendLocation();
                    } catch (Exception e) { /* "Handles error" */ }
                }

                @Override
                public void onProviderEnabled(String provider) {
                    providerEnabled = true;
                }

                @Override
                public void onProviderDisabled(String provider) {
                    providerEnabled = false;
                }

                @Override
                public void onStatusChanged(String provider, int status, Bundle extras) { }
            };

            locationManager.requestLocationUpdates(LocationManager.GPS_PROVIDER, locationRefreshInterval, 0, locationListener);
        }

        txtUsername.addTextChangedListener(new TextWatcher() {
            @Override
            public void onTextChanged(CharSequence s, int start, int before, int count) {
                if(btnLogin.getText().toString().trim().toLowerCase().equals("logged in"))
                {
                    btnSend.hide();
                    loggedIn = false;
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
            public void onClick(View v) {
                if (txtUsername.getText().toString().trim().toLowerCase().equals(username))
                {
                    txtUsername.clearFocus();
                    InputMethodManager inputManager = (InputMethodManager) getContext().getSystemService(Activity.INPUT_METHOD_SERVICE); // Hide keyboard part one
                    inputManager.hideSoftInputFromWindow(v.getWindowToken(), 0); // Hide keyboard part two

                    if (!btnLogin.getText().toString().trim().toLowerCase().equals("logged in"))
                    {
                        btnSend.show();
                        loggedIn = true;
                        btnLogin.setText("Logged In");
                        lblTracking.setVisibility(View.VISIBLE);
                        imgTracking.setVisibility(View.VISIBLE);

                        imgTracking.startAnimation(rotateAnimation);
                    }
                }
                else
                {
                    ShowSnackBar(btnSend.getRootView(), "INVALID USERNAME", errorTextColor);
                }
            }
        });

        btnSend.setOnLongClickListener(new View.OnLongClickListener() {
            @Override
            public boolean onLongClick(View v) {
                if (btnSend.isExtended())
                    btnSend.shrink();
                else
                    btnSend.extend();

                return true;
            }
        });

        btnSend.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                if (!providerEnabled ||
                        ActivityCompat.checkSelfPermission(getContext(), Manifest.permission.ACCESS_FINE_LOCATION) != PackageManager.PERMISSION_GRANTED ||
                        ActivityCompat.checkSelfPermission(getContext(), Manifest.permission.ACCESS_BACKGROUND_LOCATION) != PackageManager.PERMISSION_GRANTED ||
                        ActivityCompat.checkSelfPermission(getContext(), Manifest.permission.INTERNET) != PackageManager.PERMISSION_GRANTED)
                {
                    ShowSnackBar(v, "LOCATION DISABLED", errorTextColor);
                }
                else
                {
                    try {
                        SendLocation();
                        ShowSnackBar(v, "POSITION SENT", successTextColor);
                    } catch(Exception e) {
                        ShowSnackBar(v, "CONNECTION ERROR", errorTextColor);
                    }
                }
            }
        });
    }

    private void SendLocation() {
        if (loggedIn)
        {
            final double latitude = currentLocation.getLatitude();
            final double longitude = currentLocation.getLongitude();

            String deviceId = ""; // Currently generated from username

            for (char i : username.toCharArray()) {
                deviceId += String.valueOf((int)i);
            }

            String postUrl = "http://track-it.aggroserver.tech/phone/" + deviceId;
            RequestQueue requestQueue = Volley.newRequestQueue(getContext());

            JSONObject postData = new JSONObject();

            try {
                postData.put("lat", latitude);
                postData.put("lng", longitude);
            }
            catch (JSONException e) {
                e.printStackTrace();
            }

            JsonObjectRequest jsonObjectRequest = new JsonObjectRequest(Request.Method.POST, postUrl, postData, new Response.Listener<JSONObject>() {
                @Override
                public void onResponse(JSONObject response) {
                    Log.i("response", "response success");
                }
            }, new Response.ErrorListener() {
                @Override
                public void onErrorResponse(VolleyError error) {
                   // "Handles error"
                }
            });

            requestQueue.add(jsonObjectRequest);
        }
    }
}
package com.ruige.com.carpenter;

import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import com.ruige.com.CallBackUI.MainUI;
import com.ruige.com.Entity.MainEntity;
import com.ruige.com.GetRequestHelper.GetRequestHelper;

public class MainActivity extends AppCompatActivity implements MainUI {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
    }

    @Override
    public void result(MainEntity mainEntity) {
        GetRequestHelper.request(this);
    }
}

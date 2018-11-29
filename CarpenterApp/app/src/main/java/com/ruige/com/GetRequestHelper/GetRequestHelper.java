package com.ruige.com.GetRequestHelper;

import com.ruige.com.CallBackUI.MainUI;
import com.ruige.com.Entity.MainEntity;
import com.ruige.com.GetRequest.MainInterface;
import com.ruige.com.Utils.AttrFiel;
import retrofit2.Call;
import retrofit2.Callback;
import retrofit2.Response;
import retrofit2.Retrofit;
import retrofit2.converter.gson.GsonConverterFactory;

public class GetRequestHelper {

    public static void request(final MainUI callBackUI){

        //步骤4:创建Retrofit对象
        Retrofit retrofit=new Retrofit.Builder()
                .baseUrl(AttrFiel.MAINURL)
                .addConverterFactory(GsonConverterFactory.create())
                .build();

        // 步骤5:创建 网络请求接口 的实例
        MainInterface request=retrofit.create(MainInterface.class);
        Call<MainEntity> call=request.getCall();

        //步骤6:发送网络请求(异步)
        call.enqueue(new Callback<MainEntity>() {
            @Override
            public void onResponse(Call<MainEntity> call, Response<MainEntity> response) {
                MainEntity translation = response.body();
                translation.show();
                callBackUI.result(translation);
            }

            @Override
            public void onFailure(Call<MainEntity> call, Throwable t) {

            }
        });

    }

}

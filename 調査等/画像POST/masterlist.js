const app = new Vue({
    el: '#app',
    data: {
        dataObj: {},
        show: false,
        callBack: this.dialogClose,
        closeCallBack: this.dialogClose
    },
    methods: {
        uploadFile: function (ev) {
            let files = ev.target.files;
            var oFile = files[0];
            var m_file_name = oFile.name;
            var reader = new FileReader();
            reader.readAsBinaryString(oFile);

            //ファイル読込成功イベント
            reader.onload = function (e) {
                // データURLスキームを取得
                var data_url_scheme = reader.result;
                // データURLスキームからbase64形式のバイナリデータに変換する
                var base64 = btoa(data_url_scheme);
                base64 = base64.replace(/^.*,/, '');
                const options = {
                    headers: { 'Content-Type': 'application/json; charset=utf-8' }
                };

                param = { json: JSON.stringify(base64), fileName: m_file_name };

                axios.post(URL + '/UploadFile', param, options)
                    .then(function (response) {
                        app.dataObj = JSON.parse(response.data.d);
                    })
                    .catch(function (error) {
                        console.log(error);
                    });
            };


        },

        dialog: function () {
            this.show = true;
            this.callBack = this.jsonTest;
            this.closeCallBack = this.dialogClose;
        },
        dialogClose: function () {
            this.show = false;
        },
        // ■成功例　保存
        jsonTest: function (postType) {
            var upload_file = $('#ipt_file')[0];
            var oFile = upload_file.files[0];
            var m_file_name = oFile.name;
            var reader = new FileReader();
            reader.readAsBinaryString(oFile);

            //ファイル読込成功イベント
            reader.onload = function (e) {
                // データURLスキームを取得
                var data_url_scheme = reader.result;
                // データURLスキームからbase64形式のバイナリデータに変換する
                var base64 = btoa(data_url_scheme);
                base64 = base64.replace(/^.*,/, '');
                console.log(app.dataObj);
                // オブジェクトに設定
                app.dataObj.imageBase64 = base64;
                app.dataObj.imageFileName = m_file_name;
                console.log(app.dataObj.imageBase64);
                // ajax実行
                app.doPost(postType);
            };
        },
        doPost: function (postType) {
            const options = {
                headers: { 'Content-Type': 'application/json; charset=utf-8' }
            };
            param = { json: JSON.stringify(app.dataObj), type: postType };
            console.log(app.dataObj);
            axios.post(URL + '/DoPost', param, options)
                .then(function (response) {
                    app.dataObj = JSON.parse(response.data.d);
                })
                .catch(function (error) {
                    console.log(error);
                });
        }
    },
    beforeMount: function () {
        //  this.doPost(POST_TYPE_INIT);
    }

});


const app = new Vue({
    el: '#app',
    data: {
        dataObj: {},
        show: false,
        callBack: this.dialogClose,
        closeCallBack: this.dialogClose
    },
    methods: {
        dialog: function () {
            this.show = true;
            this.callBack = this.jsonTest;
            this.closeCallBack = this.dialogClose;
        },
        dialogClose: function () {
            this.show = false;
        },
        // ■成功例　保存
        jsonTest: function (oFile) {
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
                var param = {
                    json: JSON.stringify(base64),
                    name: m_file_name,
                    type: POST_TYPE_SELECT
                };
                axios.post(URL + '/Test', param, options)
                    .then(function (response) {
                        console.log(response);
                    })
                    .catch(function (error) {
                        console.log(error);
                    });
            };
        },
        doPost: function (postType) {
            const options = {
                headers: { 'Content-Type': 'application/json; charset=utf-8' }
            };
            if (postType === POST_TYPE_SELECT) {
                this.dataObj.text = "AAAAAAAAAAAAA";
            }
            if (postType === POST_TYPE_DELETE) {
                this.dataObj.text = "ZZZZZZZZZZZZZZZ";
            }
            var param = {
                json: JSON.stringify(this.dataObj),
                type: postType
            };



            axios.post(URL + '/Init', param, options)
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


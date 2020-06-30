var current1 = this;
var masterMixin = {
    data: {
        dataObj: {}
    },
    methods: {
        doPost: function (postType) {
            // ここが重要
            var current2 = this;
            const options = {
                headers: { 'Content-Type': 'application/json; charset=utf-8' }
            };
            param = { json: JSON.stringify(this.dataObj), type: postType };
            axios.post(URL + '/DoPost', param, options)
                .then(function (response) {
                    // OK
                    current2.dataObj = JSON.parse(response.data.d);
                    // NG  current1.dataObj = JSON.parse(response.data.d);
                    // NG     this.dataObj = JSON.parse(response.data.d);
                    // NG     masterMixin.dataObj = JSON.parse(response.data.d);

                })
                .catch(function (error) {
                    console.log(error);
                });
        }
    }
};


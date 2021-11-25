const path = require('path');
const MiniCssExtractPlugin = require("mini-css-extract-plugin");
const bundleConfig = require("./webpack.bundle.config.js");

module.exports = {
    /*entry: {
        'index': path.resolve(__dirname, 'src') + '/Home/index.js'
    },*/
    mode: 'production',
    entry: {
        ...bundleConfig.bundles,
    },
    output: {
        filename: '[name].js',
        path: path.resolve(__dirname, './wwwroot/js/bundles')
    },
    module: {
        rules: [
            {
                test: /\.js$/,
                exclude: /node_modules/,
                use: {
                    loader: "babel-loader"
                }
            },
            {
                test: /\.(sa|sc|c)ss$/,
                use: [
                    MiniCssExtractPlugin.loader,
                    'css-loader',
                    'sass-loader'
                ]
            }
        ]
    },
    plugins: [
        new MiniCssExtractPlugin({
            filename: "[name].css",
            chunkFilename: "[id].css"
        })
    ]
}
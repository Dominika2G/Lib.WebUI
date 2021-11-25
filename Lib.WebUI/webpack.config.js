const path = require('path');
const MiniCssExtractPlugin = require("mini-css-extract-plugin");
const bundleConfig = require("./webpack.bundle.config.js");

const { CleanWebpackPlugin } = require('clean-webpack-plugin');
const { WebpackManifestPlugin } = require('webpack-manifest-plugin');
const pathToManifest = './Webpack/manifest.json';
const pathToManifestDev = './bin/Debug/netcoreapp3.1/Webpack/manifest.json';

module.exports = {
    mode: 'production',
    entry: {
        ...bundleConfig.bundles,
    },
    output: {
        filename: '[name].[chunkhash].js',
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
                test: /\.css$/,
                use: [
                    {
                        loader: 'style-loader'
                    },
                    {
                        loader: 'css-loader'
                    }
                ]
            },
            {
                test: /\.scss$/,
                use: [
                    {
                        loader: 'style-loader'
                    },
                    {
                        loader: MiniCssExtractPlugin.loader,
                        options: {
                            esModule: false,
                        },
                    },
                    {
                        loader: 'css-loader',
                        options: {
                            url: false
                        }
                    },
                    {
                        loader: 'sass-loader',
                        options: {
                            sourceMap: true,
                            sassOptions: {
                                includePaths: ['absolute/path/a']
                            }
                        }
                    }
                ]
            },
            /*{
                test: /\.(sa|sc|c)ss$/,
                use: [
                    MiniCssExtractPlugin.loader,
                    'css-loader',
                    'sass-loader'
                ]
            },*/
            {
                test: /\.(png|jp(e*)g|svg)$/,
                use: [{
                    loader: 'url-loader',
                    options: {
                        name: 'images/[hash]-[name].[ext]'
                    }
                }]
            }
        ]
    },
    plugins: [
        new MiniCssExtractPlugin({
            filename: "[name].[chunkhash].bundle.css",
            chunkFilename: "[id].[chunkhash].bundle.css"
        }),
        new CleanWebpackPlugin(),
        new WebpackManifestPlugin({
            fileName: path.resolve(__dirname, pathToManifest)
        }),
        new WebpackManifestPlugin({
            fileName: path.resolve(__dirname, pathToManifestDev)
        })
    ]
}
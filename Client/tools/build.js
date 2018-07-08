/*eslint-disable no-console */
import webpack from 'webpack';
import webpackConfig from '../webpack.config.prod';
import colors from 'colors';

process.env.NODE_ENV = 'production';

console.log('Generating minified bundle');

webpack(webpackConfig).run((err, status) => {
  if(err){
    console.log(err.bold.red);
    return 1;
  }

  const jsonStatus = status.toJson();

  if(jsonStatus.hasErros){
    console.log("errors:");
    return jsonStatus.errors.map(error => console.log(error.red));
  }

  if(jsonStatus.hasWarnings){
    console.log("warnings: ".bold.yellow);
    return jsonStatus.warnings.map(warning => console.log(warning.yellow));
  }

  console.log(`Webpack status: ${status}`);

  console.log('App compiled in Production');

  return 0;
});

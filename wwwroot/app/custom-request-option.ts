import { Injectable } from '@angular/core';
import { RequestOptions, RequestOptionsArgs } from '@angular/http';

@Injectable()
export class CustomRequestOptions extends RequestOptions {
  merge(options?: RequestOptionsArgs): RequestOptions {
    if (options !== null && options.url !== null) {
      options.url = 'http://localhost:3000' + options.url;
    }
    let requestOptions = super.merge(options)
    return new CustomRequestOptions({
      method: requestOptions.method,
      url: requestOptions.url,
      search: requestOptions.search,
      headers: requestOptions.headers,
      body: requestOptions.body,
      withCredentials: requestOptions.withCredentials,
      responseType: requestOptions.responseType
    });
  }
}
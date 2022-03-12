import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';

import { MDMTable, MDMSearchModel } from '../models/MDMSearchModel';
import { map, Observable } from 'rxjs';

@Injectable()
export class ElasticsearchService {
  baseUrl = 'http://localhost:5262/api/MdmSearch/';

  constructor(private http: HttpClient) {}

  fullTextSearch(_table: MDMTable, _queryText:string) : Observable<MDMSearchModel[]> {
    console.log(_table + ' ' + _queryText);
    let qparams = new HttpParams();
    qparams = qparams.append('table', _table);
    qparams = qparams.append('query', _queryText);

    return this.http.get<MDMSearchModel[]>(`http://localhost:5262/api/MdmSearch/search`, { params: qparams } );
    

    // return this.http.get<MDMSearchModel[]>(
    //   this.baseUrl + 'search',{observe: 'response', params})
    //     .pipe(
    //         map((response : any)=>{
    //             return response;
    //         })
    //     )
    
  }
}

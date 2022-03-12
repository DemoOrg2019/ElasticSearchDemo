import { Component, OnInit } from '@angular/core';
import { map, Observable } from 'rxjs';

import {MDMSearchModel, MDMSearchModelSource, MDMTable} from '../../models/MDMSearchModel'
import { ElasticsearchService } from '../../services/elasticsearch.service'
 
@Component({
  selector: 'mdm-search',
  templateUrl: './mdm-search.component.html',
  styleUrls: ['./mdm-search.component.scss'],
})
export class MdmSearchComponent implements OnInit {

    private readonly INDEX : string = 'mdm-register-lcl-01';
    private readonly TYPE : string = '';

    public mDMSearchModelSources : MDMSearchModel[] = new Array<MDMSearchModel>();

    public queryText = '';

    public lastKeypress = 0;
  
    constructor(private es: ElasticsearchService) {
      this.queryText = '';
    }

    ngOnInit(): void {
    }

    search($event : any) {
        if ($event.timeStamp - this.lastKeypress > 100) {
          this.queryText = $event.target.value;

          // this.mDMSearchModelSources = this.es.fullTextSearch(            
          //   1,
          //   this.queryText);
          console.log('About to search ');
          this.es.fullTextSearch(1, this.queryText)
          .subscribe((res : any) => {
            console.log('recieved response ' + res);
            this.mDMSearchModelSources = res; 
          });
          
          // .pipe(
          //   map((res : any) => {
          //     console.log('recieved response ' + res);
          //     this.mDMSearchModelSources = res; 
          //   }
          //   ));

            // .then(
            // ( response : any ) => {
            //   this.mDMSearchModelSources = response;
            //   console.log(response);
            // }, (error : any) => {
            //   console.error(error);
            // }).then(() => {
            //   console.log('Search Completed!');
            // });
        }
    
        this.lastKeypress = $event.timeStamp;
      }
    
}
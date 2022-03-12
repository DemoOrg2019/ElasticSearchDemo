import {Injectable} from '@angular/core';
import {DefaultDataService, HttpUrlGenerator} from '@ngrx/data';
import {Course} from '../model/course';
import {HttpClient} from '@angular/common/http';
import {Observable} from 'rxjs';
import {map} from 'rxjs/operators';



@Injectable()
export class CoursesDataService extends DefaultDataService<Course> {


    coursesData: Course[] = [
        {
            "id": 1,
            "seqNo": 1,
            "url": "test1",
            "iconUrl": "test1icon1",
            "courseListIcon": "test1loc1",
            "description": "ABCDEFGHIJKLMNOPQRSTUV",
            "longDescription": "ABCDEFGHIJKLMNOPQRST",
            "category": "a",
            "lessonsCount": 4,
            "promo": true
          },
          {
            "id": 2,
            "seqNo": 2,
            "url": "test2",
            "iconUrl": "test1icon2",
            "courseListIcon": "test1loc2",
            "description": "ABCDEFGHIJKLMNOPQRSTUV",
            "longDescription": "ABCDEFGHIJKLMNOPQRST",
            "category": "a",
            "lessonsCount": 4,
            "promo": true
          }
    ];

    constructor(http:HttpClient, httpUrlGenerator: HttpUrlGenerator) {
        super('Course', http, httpUrlGenerator);

    }

    override getAll(): Observable<Course[]> {
        // return this.http.get('/api/courses')
        //     .pipe(
        //         map(res => res["payload"])
        //     );

        return this.http.get<Course[]>("http://localhost:3000/courses");
        // .pipe(
        //     map(res => res)
        // );
    }

}

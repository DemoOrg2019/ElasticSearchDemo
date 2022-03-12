import { Component, OnInit } from '@angular/core';

import {
  EntityCollectionService,
  EntityCollectionServiceFactory,
} from '@ngrx/data';
import { map, Observable } from 'rxjs';
// import * as fromCourse from '@data-demo/core/data-access-lookup';
import { Course } from '@data-demo/core/data-access-lookup'; 
import { CourseEntityService } from 'libs/core/data-access-lookup/src/lib/course/services/course-entity.service';
 
@Component({
  selector: 'app-courses',
  templateUrl: './courses.component.html',
  styleUrls: ['./courses.component.scss'],
})
export class CoursesComponent implements OnInit {
  // allCourses =  this.courseService.entities$
  // .pipe(
  //   map( courses => courses.values)
  // );
  allCourses$: Observable<Course[]>;
  // courseService: EntityCollectionService<Course>;

  // constructor(entityCollectionServiceFactory: EntityCollectionServiceFactory) {
  //   this.courseService =
  //     entityCollectionServiceFactory.create<Course>("Course");
  //   this.allCourses$ = this.courseService.entities$;
  // }

/*
this.oilCompanies$=this.companyEntityServiec.entities$.pipe

    (

      map(companies=>companies.filter(company=>company.isActive==true))

    ) ;
*/

  constructor(private courseService: CourseEntityService) {
    this.courseService.getAll();
    console.log(this.courseService.entities$);
    this.allCourses$ = this.courseService.entities$
    .pipe(
      map( courses => courses)
    );
  }
 
  ngOnInit(): void {
    
  }
}
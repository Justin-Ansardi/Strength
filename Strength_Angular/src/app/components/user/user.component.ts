import { Component, OnInit } from '@angular/core';
import { ApiService } from '../../api.service';
import { map, Observable, take } from 'rxjs';
import { CommonModule } from '@angular/common';


@Component({
  selector: 'app-user',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './user.component.html',
  styleUrl: './user.component.css'
})
export class UserComponent implements OnInit {
  data$!: Observable<any>;
  constructor(private apiService: ApiService) { }


  ngOnInit(): void {
    this.data$ = this.apiService.getData().pipe(take(1));
  }
}


// export class UserComponent implements OnInit {
//   data: any;
//   constructor(private apiService: ApiService) { }


//   ngOnInit(): void {
//     this.apiService.getData().subscribe(response => {
//       this.data = response,
//         console.log(response)
//     })

//   }
// }



import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
    providedIn: 'root'
})
export class ApiService {

    private baseUrl: string = 'https://localhost:7219/Home'; // Update with your API endpoint

    constructor(private http: HttpClient) { }

    getData(): Observable<any> {
        return this.http.get<any[]>(`${this.baseUrl}`); // Example API endpoint
    }


    postData(payload: any): Observable<any> {
        return this.http.post(`${this.baseUrl}`, payload); // Example API endpoint
    }

    // Add more methods as necessary
}
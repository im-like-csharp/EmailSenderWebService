import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { MailRequest } from './mail-request';

@Injectable()
export class DataService {

    private url = "https://localhost:7080/api/Mail";

    constructor(private http: HttpClient) {
    }

    sendMessages(request: MailRequest) {
        return this.http.post(this.url, request);
    }
}
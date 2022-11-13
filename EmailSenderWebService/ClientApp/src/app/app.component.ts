import { Component, OnInit } from '@angular/core';
import { DataService } from './data.service';
import { MailRequest } from './mail-request';

@Component({
    selector: 'app',
    templateUrl: './app.component.html',
    providers: [DataService]
})
export class AppComponent {

    request: MailRequest = new MailRequest();   // изменяемый товар
    tableMode: boolean = true; 

    constructor(private dataService: DataService) { }

    // сохранение данных
    send() {
        this.dataService.sendMessages(this.request).subscribe({
            error: error => console.log(error)
        });
    }

    add(): void {
        this.tableMode = false;
    }

    cancel(): void {
        this.tableMode = true;
    }
}